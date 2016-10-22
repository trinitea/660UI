using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Genre : Catalog<Genre>
{
    static public void LoadCatalog(bool reload)
    {
        if(CatItems == null || reload)
        {
            RestHelper.Instance.GetGenres(ReadCatalogData);
        }
    }

    static public void ReadCatalogData(RestResponse response)
    {
        if (response.Error != string.Empty)
        {

            // read stuff here
        }
    }
}
