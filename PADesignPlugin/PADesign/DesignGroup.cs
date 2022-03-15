using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADesign
{
    internal class DesignGroup

    {
        public string Name { get; set; }
        private Dictionary<string,FFDModule> Modules { set; get; }
        public DesignGroup(string name="DG1")
        {
            Modules = new Dictionary<string, FFDModule>();
            Name = name;
         }

        public DesignGroup(string moduleName, FFDModule mod, string name = "DG1")
        {
            Modules = new Dictionary<string, FFDModule>();
            Modules.Add(moduleName, mod);
            Name = name;
        }
        public Boolean Add(string moduleName, FFDModule mod)
        {
            try
            {
                Modules.Add(moduleName, mod);
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

           
        }
        public List<string> GetModules()
        {
            return Modules.Keys.ToList<string>(); 
        }
               
        public Boolean Del(string moduleName)
        {
            try
            {
                Modules.Remove(moduleName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Modify(string moduleName, FFDModule mod)
        {
            try
            {
                Modules[moduleName] = mod;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
