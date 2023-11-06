using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
<<<<<<< HEAD
    public static class RaycasterManager
    {
        private static readonly List<BaseRaycaster> s_Raycasters = new List<BaseRaycaster>();

        internal static void AddRaycaster(BaseRaycaster baseRaycaster)
=======
    internal static class RaycasterManager
    {
        private static readonly List<BaseRaycaster> s_Raycasters = new List<BaseRaycaster>();

        public static void AddRaycaster(BaseRaycaster baseRaycaster)
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
        {
            if (s_Raycasters.Contains(baseRaycaster))
                return;

            s_Raycasters.Add(baseRaycaster);
        }

<<<<<<< HEAD
        /// <summary>
        /// List of BaseRaycasters that has been registered.
        /// </summary>
=======
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
        public static List<BaseRaycaster> GetRaycasters()
        {
            return s_Raycasters;
        }

<<<<<<< HEAD
        internal static void RemoveRaycasters(BaseRaycaster baseRaycaster)
=======
        public static void RemoveRaycasters(BaseRaycaster baseRaycaster)
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
        {
            if (!s_Raycasters.Contains(baseRaycaster))
                return;
            s_Raycasters.Remove(baseRaycaster);
        }
    }
}
