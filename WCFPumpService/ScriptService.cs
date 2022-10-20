﻿using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WCFPumpService
{
    public class ScriptService : IScriptService
    {
        private CompilerResults results = null;
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingsService _settingsService;
        private readonly IPumpServiceCallback _callback;

        public ScriptService(IPumpServiceCallback callback, ISettingsService settingsService, IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            _settingsService = settingsService;
            _callback = callback;
        }

        public bool Compile()
        {
            try
            {
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.GenerateInMemory = true;
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("System.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                FileStream fileStream = new FileStream(_settingsService.FileName, FileMode.Open);
                byte[] buffer;
                try
                {
                    int length = (int)fileStream.Length;
                    buffer = new byte[length];
                    int count;
                    int sum = 0;
                    while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                        sum += count;
                }
                finally
                {
                    fileStream.Close();
                }

                CSharpCodeProvider provider = new CSharpCodeProvider();
                results = provider.CompileAssemblyFromSource(compilerParameters, System.Text.Encoding.UTF8.GetString(buffer));
                if (results.Errors != null && results.Errors.Count != 0)
                {
                    string compilerErrors = string.Empty;
                    for (int i = 0; i < results.Errors.Count; i++)
                    {
                        if (compilerErrors != String.Empty)
                        {
                            compilerErrors += "\n";
                        }

                        compilerErrors += results.Errors[i];
                    }

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Run(int count)
        {
            if (results == null || (results != null && results.Errors != null && results.Errors.Count > 0))
            {
                if (Compile() == false)
                {
                    return;
                }
            }

            Type t = results.CompiledAssembly.GetType("Sample.SampleScript");
            if (t == null)
            {
                return;
            }

            MethodInfo entryPointMethod = t.GetMethod("EntryPoint");
            if (entryPointMethod == null)
            {
                return;
            }

            Task.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    if ((bool)entryPointMethod.Invoke(Activator.CreateInstance(t), null))
                    {
                        _statisticsService.SuccessTacts++;
                    }
                    else
                    {
                        _statisticsService.ErrorTacts++;
                    }

                    _statisticsService.AllTacts++;
                    _callback.UpdateStatistic((StatisticsService)_statisticsService);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}