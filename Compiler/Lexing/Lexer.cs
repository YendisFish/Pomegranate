namespace Compiler.Lexing
{
    internal class Lexer
    {
        public string Content { get; set; }
        public int index { get; set; }
        public Lexer(string path)
        {
            Content = File.ReadAllText(path);
        }

        public List<(Token token, string value, int[] indexes)> ParseFile()
        {
            List<(Token token, string value, int[] indexes)> ret = new();

            string fgmnt = "";
            List<int> dxs = new();

            for(int i = 0; i < Content.Length; i++)
            {
                switch(Content[i])
                {
                    //killchars = ( ) { } [ ] , : " ' ; + - /
                    case ' ':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.WHITESPACE;
                        val.value = " ";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '(':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.LP;
                        val.value = "(";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case ')':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.RP;
                        val.value = ")";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '[':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.LB;
                        val.value = "[";
                        val.indexes = new int[] { i };
                        
                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case ']':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.RB;
                        val.value = "]";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";
                        
                        continue;
                    }

                    case '{':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.LCB;
                        val.value = "{";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '}':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.RCB;
                        val.value = "}";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case ',':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.COMMA;
                        val.value = ",";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case ':':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.COLON;
                        val.value = ":";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '\"':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.DOUBLEQUOTE;
                        val.value = "\"";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '\'':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.QUOTE;
                        val.value = "\'";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case ';':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.SEMICOLON;
                        val.value = ";";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '+':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.ADD;
                        val.value = "+";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '/':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.DIVIDE;
                        val.value = "/";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '\\':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.ESCAPEINDICATOR;
                        val.value = "\\";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";

                        continue;
                    }

                    case '*':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.POINTERREF;
                        val.value = "*";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";
                        
                        continue;
                    }

                    case '&':
                    {
                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.POINTERDEREF;
                        val.value = "&";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";
                        
                        continue;
                    }

                    case '>':
                    {
                        if(Content[i - 1] == '-')
                        {
                            continue;
                        }

                        (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                        (Token token, string value, int[] indexes) val = new();
                        val.token = Token.BOOLEANGREATERTHAN;
                        val.value = ">";
                        val.indexes = new int[] { i };

                        ret.Add(fgparsed);
                        ret.Add(val);

                        fgmnt = "";
                        
                        continue;
                    }

                    case '-':
                    {
                        if(Content[i + 1] == '>')
                        {
                            (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                            (Token token, string value, int[] indexes) val = new();
                            val.token = Token.POINTEREXTENSION;
                            val.value = "->";
                            val.indexes = new int[] { i };

                            ret.Add(fgparsed);
                            ret.Add(val);

                            fgmnt = "";
                            
                            continue;
                        } else {
                            (Token token, string value, int[] indexes) fgparsed = ParseFragment(fgmnt, dxs);

                            (Token token, string value, int[] indexes) val = new();
                            val.token = Token.SUBTRACT;
                            val.value = "-";
                            val.indexes = new int[] { i };

                            ret.Add(fgparsed);
                            ret.Add(val);

                            fgmnt = "";
                            
                            continue;
                        }
                    }
                }

                fgmnt = fgmnt + Content[i];
                dxs.Add(i);
            }

            return ret;
        }

        public (Token token, string value, int[] indexes) ParseFragment(string fg, List<int> dxs)
        {
            switch(fg)
            {
                case "==":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.BOOLEANEQUALS;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "=":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.ASSIGNMENTEQUALS;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "int":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.INT;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "char":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.CHAR;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "byte":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.BYTE;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "return":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.RETURN;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "struct":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.STRUCT;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "class":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.CLASS;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "heapalloc":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.HEAPALLOC;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "transform":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.TRANSFORM;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "if":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.IF;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "else":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.ELSE;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "while":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.WHILE;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "bool":
                {
                    (Token token, string value, int[] indexes) val = new();
                    val.token = Token.BOOL;
                    val.value = fg;
                    val.indexes = dxs.ToArray();

                    return val;
                }

                case "external":
                {
                    (Token token, string value, int[] indexes) ret = new();
                    ret.token = Token.EXTERNAL;
                    ret.value = fg;
                    ret.indexes = dxs.ToArray();
                    
                    return ret;
                }

                case "asm":
                {
                    (Token token, string value, int[] indexes) ret = new();
                    ret.token = Token.ASM;
                    ret.value = fg;
                    ret.indexes = dxs.ToArray();
                    
                    return ret;
                }

                default:
                {
                    (Token token, string value, int[] indexes) ret = new();
                    ret.token = Token.NAME;
                    ret.value = fg;
                    ret.indexes = dxs.ToArray();
                    
                    return ret;
                }
            }
        }
    }
}