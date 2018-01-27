//
// MyClass.cs
//
// Author:
//       Sogurov Fiodor <f.songurov@software-dep.net>
//
// Copyright (c) 2017 Songurov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Diagnostics;
using System.Reflection;
using Core.Services;
using Core.Services.MockServices;
using Core.Services.MockServices.Interfaces;
using Core.Services.MockServices.RealServices;
using Core.Services.RealServices;
using I18NPortable;
using Int.Core.Application.Exception;
using Int.Core.Application.Login.Contract;
using Int.Core.Application.Menu.Contract;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Network.Singleton;
using Splat;

namespace Core
{
    public sealed class App : Singleton<App>
    {
        public const string ServiceContractMock = "mock";
        public const string ServiceContract = "service_contract";

        public bool IsMock { get; private set; }

        public bool IsDroid { get; set; } = true;

        public string NameSpacePage()
        {
            return IsDroid ? "Droid.Page" : "iOS.Storyboard";
        }

        public IBaseViewModel GetView(Type type)
        {
            return Service.Instance.ServiceViewModel.Get(type);
        }

        public void Start()
        {
            I18N.Current
                .SetNotFoundSymbol("$")
                .SetFallbackLocale("resources/it")
                .SetThrowWhenKeyNotFound(true)
                .Init(typeof(App).GetTypeInfo().Assembly);

            IsMock = false;

            if (IsMock)
                InjectMockServices();
            else
                InjectServices();

            Service.Instance.Start();

            ExceptionLogger.NonFatalException -= LogExceptionInAppOutput;
            ExceptionLogger.NonFatalException += LogExceptionInAppOutput;
        }

        private static void InjectServices()
        {
            Locator.CurrentMutable.RegisterConstant(
                new MenuService(), typeof(IMenu<IItemMenu>), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new AuthenticateService(), typeof(ILogin), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new ContractService(), typeof(IContractService), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                new DocumentService(), typeof(IDocumentService), ServiceContract);

            Locator.CurrentMutable.RegisterConstant(
                 new ComunicationService(), typeof(IComunicationService), ServiceContract);
        }

        private static void InjectMockServices()
        {
            Locator.CurrentMutable.RegisterConstant(
                new AuthenticateServiceMock(), typeof(ILogin), ServiceContractMock);
            Locator.CurrentMutable.RegisterConstant(
                new MenuService(), typeof(IMenu<IItemMenu>), ServiceContractMock);
            Locator.CurrentMutable.RegisterConstant(
                new ContractService(), typeof(IContractService), ServiceContractMock);
            Locator.CurrentMutable.RegisterConstant(
                new DocumentService(), typeof(IDocumentService), ServiceContractMock);
            Locator.CurrentMutable.RegisterConstant(
                new ComunicationService(), typeof(IComunicationService), ServiceContractMock);
        }

        private static void LogExceptionInAppOutput(Exception e)
        {
            Debug.WriteLine($"[{typeof(ExceptionLogger).Name}] {e.Message}");
        }
    }
}