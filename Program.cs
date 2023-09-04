using SatSolverLib;

switch (args.Length)
{
    case 0:
        throw new ArgumentException("File path is not found");
    case > 1:
        throw new ArgumentException("There are more than one file paths");
}

var filePath = args[0].Replace("\"", "");

if (!File.Exists(filePath))
    throw new ArgumentException($"File on path {filePath} does not exist");

var cnf = DimacsParser.ParseFile(filePath);
var isSat = Solver.Dpll(cnf, out var solution);

DimacsParser.WriteModelToConsole(solution);