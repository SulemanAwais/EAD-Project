using Microsoft.Data.SqlClient;
using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.Models.Repositories
{
    public class ContentRepository:IContent
    {
        public List<Content> GetContent()
        {
            List<Content> contentList = new List<Content>();
            var db = new ApplicationDBContext();
            var query = from content in db.contents select content;
            foreach (var item in query)
            {
                contentList.Add(item);
            }
            return contentList;
        }
    }
}
