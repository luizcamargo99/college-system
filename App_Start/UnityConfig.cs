using MagniUniveristy.DAL.Repositories;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace MagniUniveristy
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IHomeService, HomeService>();

            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();

            container.RegisterType<ValidationViewModel, ValidationViewModel>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}