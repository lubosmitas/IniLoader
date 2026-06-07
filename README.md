\# IniLoader



Simple .NET library for loading INI configuration files and mapping values into C# objects using attributes.



\---



\## 📌 Features



\- Reads classic INI files

\- Supports sections `\[config]`

\- Supports inline comments (`; comment`)

\- Automatic mapping to objects via attributes

\- Supports conversion to:

&#x20; - string

&#x20; - int (including hex values like `0xFE`)

&#x20; - bool

&#x20; - double

&#x20; - long

\- Reflection-based object binding

\- WinForms demo with PropertyGrid



\---



\## 🧩 Attribute usage



Properties or fields must be marked with `IniItemAttribute`:



```csharp

using IniLoader;



public class Config

{

&#x20;   \[IniItem("text")]

&#x20;   public string Text { get; set; }



&#x20;   \[IniItem("number")]

&#x20;   public int Number { get; set; }



&#x20;   \[IniItem("bit")]

&#x20;   public bool Bit { get; set; }

}

