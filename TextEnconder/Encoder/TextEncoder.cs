using System;
using System.Collections.Generic;
using System.Text;

public class TextEncoder
{
    private readonly char escapingCharacter;
    private readonly Dictionary<char, char> encodingMap;
    private readonly Dictionary<char, char> decodingMap;

    public TextEncoder(char escapingCharacter = ',')
    {
        this.escapingCharacter = escapingCharacter;
        this.encodingMap = new Dictionary<char, char>();
        this.decodingMap = new Dictionary<char, char>();
    }

    public void AddMapping(char originalChar, char encodedChar)
    {
        encodingMap[originalChar] = encodedChar;
        decodingMap[encodedChar] = originalChar;
    }

    public string Encode(string text)
    {
        if (text == null)
            throw new ArgumentNullException("Input is empty");

        StringBuilder encodedText = new StringBuilder(text.Length);

        foreach (char c in text)
        {
            if (encodingMap.TryGetValue(c, out char encodedChar))
            {
                encodedText.Append(escapingCharacter);
                encodedText.Append(encodedChar);
            }
            else
            {
                encodedText.Append(c);
            }
        }

        return encodedText.ToString();
    }

    public string Decode(string encodedText)
    {
        if (encodedText == null)
            throw new ArgumentNullException(nameof(encodedText));

        StringBuilder decodedText = new StringBuilder(encodedText.Length);

        for (int i = 0; i < encodedText.Length; i++)
        {
            char character = encodedText[i];

            if (character == escapingCharacter && i < encodedText.Length - 1)
            {
                char encodedChar = encodedText[++i];
                if (decodingMap.TryGetValue(encodedChar, out char originalChar))
                {
                    decodedText.Append(originalChar);
                }
                else
                {
                    decodedText.Append(escapingCharacter);
                    decodedText.Append(encodedChar);
                }
            }
            else
            {
                decodedText.Append(character);
            }
        }

        return decodedText.ToString();
    }
}
