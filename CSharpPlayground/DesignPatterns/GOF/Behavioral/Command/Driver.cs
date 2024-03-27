/* This example demonstrates how to apply the Command pattern for undo/redo functionality 
* in a text editor, encapsulating each edit operation within command objects. 
* This allows for flexible and extensible editing features, 
* such as implementing new types of edit operations without modifying the core editor logic. */

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Command
{
    public static class Driver
    {
        public static void Run()
        {
            Document document = new Document();
            CommandManager commandManager = new CommandManager();

            commandManager.ExecuteCommand(new InsertTextCommand(document, "Hello, ", 0));
            commandManager.ExecuteCommand(new InsertTextCommand(document, " World!", 6));
            Console.WriteLine(document);

            commandManager.Undo();
            Console.WriteLine(document);

            commandManager.Redo();
            Console.WriteLine(document);

            commandManager.ExecuteCommand(new DeleteTextCommand(document, 0, 5));
            Console.WriteLine(document);

            commandManager.Undo();
            Console.WriteLine(document);
        }
    }
}
