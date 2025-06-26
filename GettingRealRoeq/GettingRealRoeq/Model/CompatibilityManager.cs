using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
   
        public class CompatibilityManager
        {
            public List<Robot> Robots { get; set; }
            public List<TopModule> TopModules { get; set; }

            public CompatibilityManager()
            {
                /* initialisering af robotter og tilføjelse af compatible topmoduler */
                Robots = new List<Robot>
        {
            new Robot("MIR 250", 1, new List<int> { 1, 2 }),
            new Robot("Continental IL600/1200", 2, new List<int> { 2 }),
            new Robot("Omron MD650", 3, new List<int> { 3 }),
            new Robot("Omron MD900", 4, new List<int> { 4 })
        };

                /* initialisering af topmoduler */
                TopModules = new List<TopModule>
        {
            new TopModule("TR125", 1),
            new TopModule("TR600", 2),
            new TopModule("TML500 EU", 3),
            new TopModule("TR550 Auto", 4)
        };
            }

            public List<TopModule> GetCompatibleModules(int robotCompabilityId)
            {
                /* Find robotten med det givne ID */
                var robot = Robots.FirstOrDefault(r => r.CompabilityId == robotCompabilityId);
                if (robot == null)
                {
                    return new List<TopModule>();  /* Retuner en tom liste hvis robot ikke findes */
                }

                /* Returner de topmoduler der er kompatible med robotten */
                return TopModules.Where(topmodules => robot.CompatibleModules.Contains(topmodules.CompabilityId)).ToList();
            }
        }
    }


