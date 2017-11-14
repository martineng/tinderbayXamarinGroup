using System;
using SQLite;

/* Coded by: Martin ENG
 * E-mail: me@martineng.info */

namespace TinderBay
{
    /* Coded by: Martin ENG
     * E-mail: me@martineng.info */

    public class LoginTable
    {
        /* LoginTable is used for the login credential 
         * Once the API is done, this part might be deleted due to security concern.
         * (As to avoid saving login info locally */

        [PrimaryKey] /* This is the keyword for Primarykey */
        public string username { get; set; }
        [MaxLength(30)]

        public string passwordHash { get; set; }
    }
}
