# Adository
<h2>What it Adository?</h2> 
<p>If you are a fans of ADO .Net and want to stick with it because you dont want to migrate to EF yet, then here is a tool for you to generate repository classes using ADO .Net. Or in other word it is a data access layer generator tool</p>

<h2>Supported Language and Database</h2>
<p>Database: SQL Server</p>
<p>Language: C# and Visual Basic</p>

<h2>How To Generate Repository Classes</h2>
<p>It's recommended to create a separated project (class library) to put the generated code.</p>
<p>1. Open The App (Build/Run the project)</p>
<p>2. Pick Language (C# or VB)</p>
<p>3. Login using sql server password or windows</p>
<p>4. Select a database node and click 'Generate Repository' Context Menu</p>
<p>5. Type your namespace name, DbContext name, and select a folder project where you want to generate the files.</p>
<p>6. In your IDE (visual studio) point to project where the files generated. Show all files, select the generated folders and files then include to your project</p>
<p>7. Note that the dbcontext class will read connection string from config file(app.config or web.config). So you must add/create your own connection string in the config file </p>

<h2>Use the generated code</h2>
<p>It's a bit similiar to how we use an EF dbcontext object.</p>
