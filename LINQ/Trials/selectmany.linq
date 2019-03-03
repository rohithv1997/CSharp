<Query Kind="Statements" />

string[] famousQuotes={"Advertising is is legalized lying","Advertising is the greatest art form of the twentieth century"};

var query1=famousQuotes.SelectMany(s=> s.Split(' ')).Distinct().Dump();

var query2=famousQuotes.Select(s=> s.Split(' ').Distinct()).Dump();