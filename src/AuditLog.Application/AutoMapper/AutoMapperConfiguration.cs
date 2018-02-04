using AutoMapper;
using System.Collections.Generic;

namespace AuditLog.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        private static List<Profile> profiles = new List<Profile>();

        public static void RegisterMappings()
        {
            Mapper.Initialize(x => {
                x.AllowNullCollections = true;

                x.AddProfile<DefaultMappingProfile>();

                foreach (Profile profile in profiles)
                {
                    x.AddProfile(profile);
                }
            });
        }

        public static void AddProfile(Profile profile)
        {
            profiles.Add(profile);
        }
    }
}
