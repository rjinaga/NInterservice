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

    /// <summary>
    /// Represents main service point for IoC System
    /// </summary>
    public static class IocServicelet
    {
        /// <summary>
        /// Configure default/global IoC Container. 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IocContainer Configure(Action<ContainerConfig> configuration)
        {
            return Configure(configuration, ContainerModel.MultiLevel);
        }

        public static IocContainer Configure(Action<ContainerConfig> configuration, ContainerModel containerModel)
        {
            var container = CreateContainer(configuration, containerModel);

            IocContainer.GlobalIocContainer = container;

            return container;
        }

        /// <summary>
        /// Create container with specified container model. <see cref= "ContainerModel" />.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IocContainer CreateContainer(Action<ContainerConfig> configuration, ContainerModel containerModel)
        {
            ContainerConfig config = new ContainerConfig(containerModel);
            configuration(config);

            //Make the ServiceOptions object read-only, don't allow the further changes to the object.
            config.ContainerOptions.MakeReadOnly();

            return new IocContainer(config);
        }

        /// <summary>
        /// Create container with MultiLevel container model. <see cref= "ContainerModel" />.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IocContainer CreateContainer(Action<ContainerConfig> configuration)
        {
            return CreateContainer(configuration, ContainerModel.MultiLevel);
        }

        /// <summary>
        /// Create container with Single container model. <see cref="ContainerModel"/>.
        /// </summary>
        /// <returns></returns>
        public static IocContainer CreateContainer()
        {
            return CreateContainer(config => { /*no default setup*/ }, ContainerModel.Single);
        }
    }

}
