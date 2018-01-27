﻿//
//  AuthenticateServiceMock.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using Int.Core.Application.Login.Contract;

namespace Core.Services.MockServices
{
    public class AuthenticateServiceMock : ILogin
    {
        public void OnChangePassword(Action<string> success, Action<string> error)
        {
            success?.Invoke("Success!");
        }

        public void OnChangeUserData(Action<string> success, Action<string> error)
        {
            success?.Invoke("Success!");
        }

        public void OnLogin(Action<string> success, Action<string> error)
        {
            success?.Invoke("Success!");
        }

        public void OnLogout(Action<string> success, Action<string> error)
        {
            success?.Invoke("Success!");
        }

        public void OnRecoveryPassword(Action<string> success, Action<string> error)
        {
            success?.Invoke("Success!");
        }
    }
}