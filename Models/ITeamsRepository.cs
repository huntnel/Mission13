using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }

        //public IEnumerable<SelectListItem> GetCountries()
        //{

        //    using (var context = new BowlingDbContext())
        //    {
        //        List<SelectListItem> teams = context.Teams.AsNoTracking()
        //            .OrderBy(n => n.TeamName)
        //                .Select(n =>
        //                new SelectListItem
        //                {
        //                    Value = n.TeamID.ToString(),
        //                    Text = n.TeamName
        //                }).ToList();
        //        var teamtip = new SelectListItem()
        //        {
        //            Value = null,
        //            Text = "--- select team ---"
        //        };
        //        teams.Insert(0, teamtip);
        //        return new SelectList(teams, "Value", "Text");
        //    }
        //}
    }
}
