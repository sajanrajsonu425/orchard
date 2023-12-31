using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.Media
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageMediaFolder = new("ManageMediaFolder", "Manage All Media Folders");
        public static readonly Permission ManageOthersMedia = new("ManageOthersMediaContent", "Manage Media For Others", new[] { ManageMediaFolder });
        public static readonly Permission ManageOwnMedia = new("ManageOwnMediaContent", "Manage Own Media", new[] { ManageOthersMedia });
        public static readonly Permission ManageMedia = new("ManageMediaContent", "Manage Media", new[] { ManageOwnMedia });
        public static readonly Permission ManageAttachedMediaFieldsFolder = new("ManageAttachedMediaFieldsFolder", "Manage Attached Media Fields Folder", new[] { ManageMediaFolder });
        public static readonly Permission ManageMediaProfiles = new("ManageMediaProfiles", "Manage Media Profiles");
        public static readonly Permission ViewMediaOptions = new("ViewMediaOptions", "View Media Options");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[]
            {
                ManageMedia,
                ManageMediaFolder,
                ManageOthersMedia,
                ManageOwnMedia,
                ManageAttachedMediaFieldsFolder,
                ManageMediaProfiles,
                ViewMediaOptions,
            }
            .AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[]
                    {
                        ManageMediaFolder,
                        ManageMediaProfiles,
                        ViewMediaOptions },
                },
                new PermissionStereotype
                {
                    Name = "Editor",
                    Permissions = new[] { ManageMedia, ManageOwnMedia },
                },
                new PermissionStereotype
                {
                    Name = "Moderator",
                },
                new PermissionStereotype
                {
                    Name = "Author",
                    Permissions = new[] { ManageOwnMedia },
                },
                new PermissionStereotype
                {
                    Name = "Contributor",
                    Permissions = new[] { ManageOwnMedia },
                },
            };
        }
    }

    public class MediaCachePermissions : IPermissionProvider
    {
        public static readonly Permission ManageAssetCache = new("ManageAssetCache", "Manage Asset Cache Folder");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageAssetCache }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageAssetCache },
                },
            };
        }
    }
}
