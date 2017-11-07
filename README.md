# Hello, Friends.
**THIS IS THE TEMPORALY README.md FILE.**
I will update this README.md file over time as we progress.

### Github Tips

* If this is your first time working on this project, please use the following command:
```
git clone https://github.com/ReturnOfTheJack/tinderbayXamarinGroup
```
By doing so you will get all the up-to-date progress of our project.

* Everytime BEFORE you start working on the project, please remember to:
```
git pull
```

* Everytime AFTER you have done something, please remember to:
```
git add .
git commit -m "Write Your Commit Message Here"
git push
```
* Check your branch, changing branch, pushing to your branch:
```
git branch 
git checkout <YourBranchName>
git push -u origin <YourBranchName>
```
Please message in the group chat on Slack as well after you have done something so we know what to do!<Enter>
And feel free to add any section in this README.md file.

### How Sqlite works
Sqlite works locally. On the surface level it is similar to the Sql database we all familiar with.<Enter>
<Enter>
So FIRST, we will need a table.<Enter>
Using the example of LoginTable.cs I created in this project:
```
using System;
using SQLite; /* This is required reference*/

namespace TinderBay
{   
    public class LoginTable
    {
        /* The concept of Sqlite table is really similar to classes */

        [PrimaryKey] /* This is the keyword for Primarykey */
        public string username { get; set; }
        [MaxLength(30)]

        public string passwordHash { get; set; }
    }
}
```

After, let's talk about how to open the database connection. <Enter>
The theory behind database are all the same, the only differences is Sqlite is local.<Enter>
Refer to the following codes:
```
    // Setting up database path
    string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");

    var db = new SQLiteConnection(dpPath); // Open connection
    var dataTable = db.Table<LoginTable>(); // Get table
    var dataNode = dataTable.Where(x => x.username == etxtUsername.Text).FirstOrDefault(); // Sending Linq Quries 

    if (dataNode != null)
    {
        // Means it found result matched from the quries
    }
    ...
```
The result will be store as dataNode, you can perform further action for example:
```
    if (dataNode.username == etxtUsername.text)
    {
        //do something 
    }
```
So this is the basic of how to retrieve information and open the connection with Sqlite.<Enter>
<Enter>
Next, will be how to actually push to the database.
```
// Set database path, open connection. Same as previous.
    string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
    var db = new SQLiteConnection(dpPath);

    db.CreateTable<LoginTable>(); // To Create Table of our class, LoginTable
    LoginTable tbl = new LoginTable();

// Simply assigning 
    tbl.username = etxtUsername.Text;
    tbl.passwordHash = text;

    db.Insert(tbl); // Insert and you are done!
```
