namespace Compiler.Lexing
{
    internal enum Token
    {
        CHAR, //char
        INT, //int
        BOOL, //bool
        BYTE, //byte
        LB, //{
        RB, //}
        LP, //(
        RP, //)
        COMMA, //,
        POINTERREF, //*
        POINTERDEREF, //&
        POINTEREXTENSION, //->
        IF, //if
        ELSE, //else
        WHILE, //while
        RETURN, //return
        CLASS, //class
        STRUCT, //struct
        ASSIGNMENTEQUALS, //=
        BOOLEANEQUALS, //==
        BOOLEANLESSTHAN, //<
        BOOLEANGREATERTHAN, //>
        ADD, //+
        SUBTRACT, //-
        DIVIDE, // /
        POWER, //^
        TRANSFORM, //transform
        HEAPALLOC //heapalloc
    }
}