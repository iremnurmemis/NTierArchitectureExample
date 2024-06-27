﻿

using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core;
using DataAccess;

namespace Business
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            var assembly=System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector=new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
