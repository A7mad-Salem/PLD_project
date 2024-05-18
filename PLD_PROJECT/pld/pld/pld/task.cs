
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_MINUS = 3, // '-'
        SYMBOL_EXCLAMEQ = 4, // '!='
        SYMBOL_QUOTE = 5, // '"'
        SYMBOL_LPAREN = 6, // '('
        SYMBOL_RPAREN = 7, // ')'
        SYMBOL_TIMES = 8, // '*'
        SYMBOL_TIMESTIMES = 9, // '**'
        SYMBOL_DIV = 10, // '/'
        SYMBOL_COLON = 11, // ':'
        SYMBOL_PLUS = 12, // '+'
        SYMBOL_LT = 13, // '<'
        SYMBOL_LTEQ = 14, // '<='
        SYMBOL_EQ = 15, // '='
        SYMBOL_EQEQ = 16, // '=='
        SYMBOL_GT = 17, // '>'
        SYMBOL_GTEQ = 18, // '>='
        SYMBOL_CASE = 19, // case
        SYMBOL_DEFAULT = 20, // Default
        SYMBOL_DO = 21, // do
        SYMBOL_ELSE = 22, // else
        SYMBOL_FALSE = 23, // FALSE
        SYMBOL_FOR = 24, // for
        SYMBOL_ID = 25, // Id
        SYMBOL_IF = 26, // if
        SYMBOL_IN = 27, // in
        SYMBOL_NEWLINE = 28, // NewLine
        SYMBOL_NUMBER = 29, // Number
        SYMBOL_PRINT = 30, // print
        SYMBOL_SWITCH = 31, // switch
        SYMBOL_TRUE = 32, // TRUE
        SYMBOL_WHILE = 33, // while
        SYMBOL_ASSIGN = 34, // <assign>
        SYMBOL_COND = 35, // <cond>
        SYMBOL_DEFAULT2 = 36, // <default>
        SYMBOL_DOMINUSWHILE_STMT = 37, // <do-while_stmt>
        SYMBOL_EXP = 38, // <exp>
        SYMBOL_EXPR = 39, // <expr>
        SYMBOL_FACTOR = 40, // <factor>
        SYMBOL_FOR_STMT = 41, // <for_stmt>
        SYMBOL_ID2 = 42, // <id>
        SYMBOL_IF_STMT = 43, // <if_stmt>
        SYMBOL_NL = 44, // <nl>
        SYMBOL_NLOPT = 45, // <nl Opt>
        SYMBOL_OPR = 46, // <opr>
        SYMBOL_PRINT_STMT = 47, // <print_stmt>
        SYMBOL_PROGRAM = 48, // <Program>
        SYMBOL_STMT = 49, // <stmt>
        SYMBOL_STMT_LIST = 50, // <stmt_list>
        SYMBOL_SWITCH_CASE = 51, // <switch_case>
        SYMBOL_SWITCH_CASES = 52, // <switch_cases>
        SYMBOL_SWITCH_STMT = 53, // <switch_stmt>
        SYMBOL_TERM = 54, // <term>
        SYMBOL_WHILE_STMT = 55  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_NL_NEWLINE = 0, // <nl> ::= NewLine <nl>
        RULE_NL_NEWLINE2 = 1, // <nl> ::= NewLine
        RULE_NLOPT_NEWLINE = 2, // <nl Opt> ::= NewLine <nl Opt>
        RULE_NLOPT = 3, // <nl Opt> ::= 
        RULE_PROGRAM = 4, // <Program> ::= <nl Opt> <stmt_list>
        RULE_STMT_LIST = 5, // <stmt_list> ::= <stmt> <stmt_list>
        RULE_STMT_LIST2 = 6, // <stmt_list> ::= <stmt>
        RULE_STMT = 7, // <stmt> ::= <assign>
        RULE_STMT2 = 8, // <stmt> ::= <if_stmt>
        RULE_STMT3 = 9, // <stmt> ::= <for_stmt>
        RULE_STMT4 = 10, // <stmt> ::= <while_stmt>
        RULE_STMT5 = 11, // <stmt> ::= <do-while_stmt>
        RULE_STMT6 = 12, // <stmt> ::= <switch_stmt>
        RULE_STMT7 = 13, // <stmt> ::= <print_stmt>
        RULE_ASSIGN_EQ = 14, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID = 15, // <id> ::= Id
        RULE_EXPR_PLUS = 16, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS = 17, // <expr> ::= <expr> '-' <term>
        RULE_EXPR = 18, // <expr> ::= <term>
        RULE_TERM_TIMES = 19, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV = 20, // <term> ::= <term> '/' <factor>
        RULE_TERM = 21, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES = 22, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR = 23, // <factor> ::= <exp>
        RULE_EXP = 24, // <exp> ::= <id>
        RULE_EXP_NUMBER = 25, // <exp> ::= Number
        RULE_IF_STMT_IF_COLON = 26, // <if_stmt> ::= if <cond> ':' <stmt_list>
        RULE_IF_STMT_IF_COLON_ELSE = 27, // <if_stmt> ::= if <cond> ':' <stmt_list> else <stmt_list>
        RULE_COND = 28, // <cond> ::= <expr> <opr> <expr>
        RULE_COND_TRUE = 29, // <cond> ::= TRUE
        RULE_COND_FALSE = 30, // <cond> ::= FALSE
        RULE_OPR_GT = 31, // <opr> ::= '>'
        RULE_OPR_EQEQ = 32, // <opr> ::= '=='
        RULE_OPR_LT = 33, // <opr> ::= '<'
        RULE_OPR_EXCLAMEQ = 34, // <opr> ::= '!='
        RULE_OPR_LTEQ = 35, // <opr> ::= '<='
        RULE_OPR_GTEQ = 36, // <opr> ::= '>='
        RULE_FOR_STMT_FOR_IN_COLON = 37, // <for_stmt> ::= for <id> in <expr> ':' <stmt_list>
        RULE_WHILE_STMT_WHILE_COLON = 38, // <while_stmt> ::= while <expr> ':' <stmt_list>
        RULE_DOWHILE_STMT_DO_LPAREN_RPAREN_WHILE = 39, // <do-while_stmt> ::= do '(' <stmt_list> ')' while <cond>
        RULE_SWITCH_STMT_SWITCH_COLON = 40, // <switch_stmt> ::= switch <expr> ':' <nl> <stmt_list>
        RULE_SWITCH_CASES = 41, // <switch_cases> ::= <switch_case> <expr>
        RULE_SWITCH_CASES2 = 42, // <switch_cases> ::= <switch_case> <nl> <switch_cases>
        RULE_SWITCH_CASE_CASE_COLON = 43, // <switch_case> ::= case <expr> ':' <nl> <stmt_list>
        RULE_SWITCH_CASE = 44, // <switch_case> ::= <default>
        RULE_DEFAULT_DEFAULT = 45, // <default> ::= Default
        RULE_PRINT_STMT_PRINT_LPAREN = 46, // <print_stmt> ::= print '(' <expr>
        RULE_PRINT_STMT_QUOTE_QUOTE_RPAREN = 47  // <print_stmt> ::= '"' <expr> '"' ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst ;
        ListBox lst2;
  
        public MyParser(string filename,ListBox lst,ListBox lst2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
           this.lst = lst;
           this.lst2 = lst2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent); // TokenErrorHandler هيتنفذ لما error ده يحصل
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler (TokenReadEvent);
        }

        public void Parse(string source)    // check the syntax of code right or error
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //'-'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ:
                    //'!='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_QUOTE:
                    //'"'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //'*'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES:
                    //'**'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIV:
                    //'/'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COLON:
                    //':'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //'+'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LT:
                    //'<'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LTEQ:
                    //'<='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQ:
                    //'='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQEQ:
                    //'=='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GT:
                    //'>'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GTEQ:
                    //'>='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CASE:
                    //case
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT:
                    //Default
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DO:
                    //do
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSE:
                    //else
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FALSE:
                    //FALSE
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR:
                    //for
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID:
                    //Id
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF:
                    //if
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IN:
                    //in
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE:
                    //NewLine
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NUMBER:
                    //Number
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT:
                    //print
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH:
                    //switch
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TRUE:
                    //TRUE
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //while
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN:
                    //<assign>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COND:
                    //<cond>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2:
                    //<default>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DOMINUSWHILE_STMT:
                    //<do-while_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXP:
                    //<exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPR:
                    //<expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FACTOR:
                    //<factor>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT:
                    //<for_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID2:
                    //<id>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT:
                    //<if_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NL:
                    //<nl>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NLOPT:
                    //<nl Opt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OPR:
                    //<opr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT:
                    //<print_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM:
                    //<Program>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STMT:
                    //<stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST:
                    //<stmt_list>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASE:
                    //<switch_case>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASES:
                    //<switch_cases>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT:
                    //<switch_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TERM:
                    //<term>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT:
                    //<while_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_NL_NEWLINE:
                    //<nl> ::= NewLine <nl>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NL_NEWLINE2:
                    //<nl> ::= NewLine
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NLOPT_NEWLINE:
                    //<nl Opt> ::= NewLine <nl Opt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NLOPT:
                    //<nl Opt> ::= 
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PROGRAM:
                    //<Program> ::= <nl Opt> <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT_LIST:
                    //<stmt_list> ::= <stmt> <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT_LIST2:
                    //<stmt_list> ::= <stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT:
                    //<stmt> ::= <assign>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT2:
                    //<stmt> ::= <if_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT3:
                    //<stmt> ::= <for_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT4:
                    //<stmt> ::= <while_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT5:
                    //<stmt> ::= <do-while_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT6:
                    //<stmt> ::= <switch_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT7:
                    //<stmt> ::= <print_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ:
                    //<assign> ::= <id> '=' <expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_ID:
                    //<id> ::= Id
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR_PLUS:
                    //<expr> ::= <expr> '+' <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR_MINUS:
                    //<expr> ::= <expr> '-' <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR:
                    //<expr> ::= <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_TIMES:
                    //<term> ::= <term> '*' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_DIV:
                    //<term> ::= <term> '/' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM:
                    //<term> ::= <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES:
                    //<factor> ::= <factor> '**' <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR:
                    //<factor> ::= <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP:
                    //<exp> ::= <id>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP_NUMBER:
                    //<exp> ::= Number
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON:
                    //<if_stmt> ::= if <cond> ':' <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON_ELSE:
                    //<if_stmt> ::= if <cond> ':' <stmt_list> else <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COND:
                    //<cond> ::= <expr> <opr> <expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COND_TRUE:
                    //<cond> ::= TRUE
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COND_FALSE:
                    //<cond> ::= FALSE
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_GT:
                    //<opr> ::= '>'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_EQEQ:
                    //<opr> ::= '=='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_LT:
                    //<opr> ::= '<'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_EXCLAMEQ:
                    //<opr> ::= '!='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_LTEQ:
                    //<opr> ::= '<='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OPR_GTEQ:
                    //<opr> ::= '>='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_IN_COLON:
                    //<for_stmt> ::= for <id> in <expr> ':' <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_COLON:
                    //<while_stmt> ::= while <expr> ':' <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DOWHILE_STMT_DO_LPAREN_RPAREN_WHILE:
                    //<do-while_stmt> ::= do '(' <stmt_list> ')' while <cond>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_COLON:
                    //<switch_stmt> ::= switch <expr> ':' <nl> <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_CASES:
                    //<switch_cases> ::= <switch_case> <expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_CASES2:
                    //<switch_cases> ::= <switch_case> <nl> <switch_cases>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_CASE_COLON:
                    //<switch_case> ::= case <expr> ':' <nl> <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_CASE:
                    //<switch_case> ::= <default>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT:
                    //<default> ::= Default
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN:
                    //<print_stmt> ::= print '(' <expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRINT_STMT_QUOTE_QUOTE_RPAREN:
                    //<print_stmt> ::= '"' <expr> '"' ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + " in line " + args.UnexpectedToken.Location.LineNr;
            //todo: Report message to UI?
            lst.Items.Add(message);
            string m2 = " Expected tocken : " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
        }
        public void TokenReadEvent(LALRParser parse, TokenReadEventArgs arg)
        {

            String x = arg.Token.Text + "   \t \t" + (SymbolConstants)arg.Token.Symbol.Id;
            // display lexeme              display (token) or lexeme نوع

            lst2.Items.Add(x);

        }

    }
}
