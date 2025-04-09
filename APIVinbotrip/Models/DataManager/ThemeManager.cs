using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class ThemeManager : IDataRepository<Theme>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public ThemeManager() { }
        public ThemeManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Theme>>> GetAll()
        {
            return vinotripDBContext.Themes.ToList();
        }
        public async Task<ActionResult<Theme>> GetById(int id)
        {
            return  vinotripDBContext.Themes.FirstOrDefault(u => u.IdTheme == id);
        }
        public  async Task<ActionResult<Theme>> GetByString(string nomtheme)
        {
            return  vinotripDBContext.Themes.FirstOrDefault(u => u.LibelleTheme.ToUpper() == nomtheme.ToUpper());
        }
        public async Task Add(Theme entity)
        {
             vinotripDBContext.Themes.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Theme theme, Theme entity)
        {
            vinotripDBContext.Entry(theme).State = EntityState.Modified;
            theme.IdTheme = theme.IdTheme;
            theme.LibelleTheme = entity.LibelleTheme;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Theme theme)
        {
            vinotripDBContext.Themes.Remove(theme);
             vinotripDBContext.SaveChanges();
        }
    }
}
