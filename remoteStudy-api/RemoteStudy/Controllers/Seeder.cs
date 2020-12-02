using Microsoft.AspNetCore.Identity;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Controllers
{
    public class Seeder
    {
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly RemoteStudyContext _context;

        public Seeder(UserManager<User> usermanager, RemoteStudyContext context, RoleManager<Role> roleManager)
        {
            _usermanager = usermanager;
            _context = context;
            _rolemanager = roleManager;
        }
        public async Task Seed()
        {
            string[] roleNames = { "Admin", "Teacher", "Student" };

            foreach (var x in roleNames)
            {
                if (_context.Roles.Where(r => r.Name == x).Count() == 0)
                {
                    await _rolemanager.CreateAsync(new Role { Name = x });
                }
            }

            //var sub = _context.Subscriptions.Where(x => x.Name != "");
            //var users = _context.Users.Where(x => x.Email != "");

            //_context.Users.RemoveRange(users);
            //_context.Subscriptions.RemoveRange(sub);

            _context.SaveChanges();

            /*if (!_context.Subscriptions.Any())
            {
                _context.Subscriptions.AddRange(
                new Subscription { Id = Guid.Parse("28dee507-90d5-4fbe-a38d-830ba3ce4bad"), Name = "Default Subscription" },
                new Subscription { Id = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3"), Name = "Pro Subscription" });
            }

            if (!_context.Users.Any())
            {
                User user = new User { Email = "sburchinskaya.2000@gmail.com", UserName = "admin", SubscriptionId = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3") };
                await _usermanager.CreateAsync(user, "TeleBlurbDHvuehGyefv6527!");
                await _usermanager.AddToRoleAsync(user, "admin");
            }

            if (!_context.Features.Any())
            {
                _context.Features.AddRange(
                new Feature { Id = Guid.Parse("1a849204-9426-4510-b18c-fdd5e6bc0064"), Name = "Purchase Posts", Description = "Amount of purchase posts available for one day." },
                new Feature { Id = Guid.Parse("e865b664-5fcb-4eae-9408-9732688fdfca"), Name = "Sale Posts", Description = "Amount of sale posts available for one day." },
                new Feature { Id = Guid.Parse("6bc1b7e0-18e1-4d20-b952-e51453070d67"), Name = "Purchase Requests", Description = "Amount of purchase requests available for one day." },
                new Feature { Id = Guid.Parse("68a43970-8619-46d6-9995-919df3294c0f"), Name = "Sale Requests", Description = "Amount of sale requests available for one day." });
            }

            if (!_context.SubscriptionFeatures.Any())
            {
                _context.SubscriptionFeatures.AddRange(
                    // Purchase Posts for Default Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("1a849204-9426-4510-b18c-fdd5e6bc0064"), SubscriptionId = Guid.Parse("28dee507-90d5-4fbe-a38d-830ba3ce4bad"), Amount = 2 },
                    // Sale Posts for Default Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("e865b664-5fcb-4eae-9408-9732688fdfca"), SubscriptionId = Guid.Parse("28dee507-90d5-4fbe-a38d-830ba3ce4bad"), Amount = 0 },
                    // Purchase Requests for Default Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("6bc1b7e0-18e1-4d20-b952-e51453070d67"), SubscriptionId = Guid.Parse("28dee507-90d5-4fbe-a38d-830ba3ce4bad"), Amount = 10 },
                    // Sale Requests for Default Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("68a43970-8619-46d6-9995-919df3294c0f"), SubscriptionId = Guid.Parse("28dee507-90d5-4fbe-a38d-830ba3ce4bad"), Amount = 10 },

                    // Purchase Posts for Pro Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("1a849204-9426-4510-b18c-fdd5e6bc0064"), SubscriptionId = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3"), Amount = 5 },
                    // Sale Posts for Pro Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("e865b664-5fcb-4eae-9408-9732688fdfca"), SubscriptionId = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3"), Amount = 5 },
                    // Purchase Requests for Pro Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("6bc1b7e0-18e1-4d20-b952-e51453070d67"), SubscriptionId = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3"), Amount = 1000000 },
                    // Sale Requests for Pro Subscription
                    new SubscriptionFeature { FeatureId = Guid.Parse("68a43970-8619-46d6-9995-919df3294c0f"), SubscriptionId = Guid.Parse("6da50f48-53ff-442f-b121-2eb954334cf3"), Amount = 1000000 });
            }*/

            _context.SaveChanges();
        }
    }
}
