using Owin;
using University.BL.Data;

namespace University.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configura el DB Context para que sea usado por una unica instancia por request
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}
