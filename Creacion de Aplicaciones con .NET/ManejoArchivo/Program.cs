using Newtonsoft.Json;
var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

        //Creacion-Escritura-validacion de archivos/directorios
    //var creator = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201","newDir"));
    //File.WriteAllText(Path.Combine(currentDirectory, "stores", "201", "newDir","greeting.txt"), "Hello:)");
    //bool doesExist = Directory.Exists(storesDirectory);


var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"Total: {salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folder){
    List<string> SalesFiles = new List<string>();
    
    var foundFiles = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);

    foreach(var file in foundFiles){
        //the file contains the full path
        var extencion = Path.GetExtension(file);
        if(extencion == ".json"){
            SalesFiles.Add(file);
        }
    }

    return SalesFiles;
}
double CalculateSalesTotal(IEnumerable<string> salesFiles){
    double salesTotal = 0;

    //loopea cada ruta in salesFiles
    foreach(var file in salesFiles){
        //lee el contenido del archivo
        string salesJson = File.ReadAllText(file);
        //transforma a Json
        SalesData? data = JsonConvert.DeserializeObject<SalesData>(salesJson);
        //agrega el monto en el total de la variable salesTotal
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}
record SalesData(double Total);
