[assembly: WebActivator.PreApplicationStartMethod(typeof(Candidate.App_Start.ElmahMvc), "Start")]
namespace Candidate.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}