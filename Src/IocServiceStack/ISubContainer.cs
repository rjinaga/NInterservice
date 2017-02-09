﻿#region License
// Copyright (c) 2016-2017 Rajeswara Rao Jinaga
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

namespace IocServiceStack
{
    using System;
    using System.Linq.Expressions;
        
    public interface ISubContainer : IDependencyAttribute
    {
        

        IDependencyFactory Add<TC, TS>() where TC : class where TS : TC;
        IDependencyFactory Add<TC, TS>(string serviceName) where TC : class where TS : TC;

        /// <summary>
        /// Adds the specified service to the factory
        /// </summary>
        /// <typeparam name="T">The class of the service</typeparam>
        /// <param name="service">The type of the service</param>
        /// <returns>Instance <see cref="IContainerService"/> of current object</returns>
        IDependencyFactory Add<T>(Type service) where T : class;
        IDependencyFactory Add<T>(Type service, string serviceName) where T : class;


        IDependencyFactory Replace<TC, TS>() where TC : class where TS : TC;
        IDependencyFactory Replace<TC, TS>(string serviceName) where TC : class where TS : TC;

        /// <summary>
        /// Replaces the specified service in the factory.
        /// </summary>
        /// <typeparam name="T">The class of the service</typeparam>
        /// <param name="service">The type of the service</param>
        /// <returns>Instance <see cref="IContainerService"/> of current object</returns>
        IDependencyFactory Replace<T>(Type service) where T : class;
        IDependencyFactory Replace<T>(Type service, string serviceName) where T : class;
        
    }

}
