// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Data.Entity;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Concrete;
using Flock.DataAccess.Repositories.Interfaces;
using Flock.Facade.Concrete;
using Flock.Facade.Interfaces;
using Flock.Infrastructure.MapperProfile;
using StructureMap;

namespace Flock.Infrastructure.DI {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan => { 
                                scan.TheCallingAssembly();
                                scan.WithDefaultConventions();
                            });
                            x.For<DbContext>().Use<FlockContext>();
                            x.For<IUserFacade>().Use<UserFacade>();
                            x.For<IUserRepository>().Use<UserRepository>();
                            x.For<IQuackRepository>().Use<QuackRepository>();
                            x.For<IQuackFacade>().Use<QuackFacade>();
                            x.For<IQuackTypeRepository>().Use<QuackTypeRepository>();
                            x.For<IAutoMap>().Use<AutoMap>();
                            x.For<IImageFacade>().Use<ImageFacade>();
                            x.For<IQuackLikeRepository>().Use<QuackLikeRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}