﻿using Autofac;
using Project.Infrastructure.Dapper;
using Project.Infrastructure.EntityFrameworkCore;
using Project.Infrastructure.Repositories;
using Project.Web.Application.File;
using Module = Autofac.Module;

namespace Project.Web.Infrastructure
{
    /// <summary>
    /// 功能描述    ：autofac依赖注入配置
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class DependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 数据相关注入
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UnitRepository<>)).As(typeof(IUnitRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            #endregion

            #region 基础服务
            builder.RegisterType<DapperQuery>().As<IDapperQuery>().InstancePerLifetimeScope();
            builder.RegisterType<OssService>().As<IOssService>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
