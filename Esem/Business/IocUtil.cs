using Business.Abstract;
using Business.Concrete;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class IocUtil
    {
        private static IWindsorContainer _container;
        private static IWindsorContainer Container { get { if (_container == null) _container = BootstrapContainer(); return _container; } }

        private static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Register(

                Component.For<IAccountDal>().ImplementedBy<AccountDal>(),
                Component.For<IProductDal>().ImplementedBy<ProductDal>(),
                Component.For<ICategoryDal>().ImplementedBy<CategoryDal>(),
                Component.For<IMessageDal>().ImplementedBy<MessageDal>(),
                Component.For<IConversationDal>().ImplementedBy<ConversationDal>(),
                Component.For<ISaveProductDal>().ImplementedBy<SaveProductDal>(),
                Component.For<IProductService>().ImplementedBy<ProductManager>(),
                Component.For<ILoginService>().ImplementedBy<LoginManager>(),
                Component.For<IMapService>().ImplementedBy<MapManager>(),
                Component.For<IConversationService>().ImplementedBy<ConversationManager>(),
                Component.For<IAccountService>().ImplementedBy<AccountManager>(),
                Component.For<ICategoryService>().ImplementedBy<CategoryManager>(),
                Component.For<ISavedProductService>().ImplementedBy<SavedProductManager>()

                //Component.For<IWasteProductDal>().ImplementedBy<WasteProductDal>(),
                //Component.For<IDepartmentService>().ImplementedBy<DepartmentManager>(),
                //Component.For<IPersonalService>().ImplementedBy<PersonalManager>(),
                //Component.For<IProductService>().ImplementedBy<ProductManager>(),
                //Component.For<IUserService>().ImplementedBy<UserManager>(),
                //Component.For<IWarehouseService>().ImplementedBy<WarehouseManager>(),
                //Component.For<ILoginService>().ImplementedBy<LoginManager>(),

                );
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
