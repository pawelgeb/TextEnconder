

TextEncoder textEncoder = new TextEncoder();

Console.WriteLine("Welcome in Text Encoder application");
Console.WriteLine("-----------------------------------");
textEncoder.AddMapping(' ', '1');

string originalText = "a b";
string encodedText = textEncoder.Encode(originalText);
Console.WriteLine("Encoded Text: " + encodedText);

string decodedText = textEncoder.Decode(encodedText);
Console.WriteLine("Decoded Text: " + decodedText);
