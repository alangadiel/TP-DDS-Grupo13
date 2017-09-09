grammar Gramatica;

/*
 * Parser Rules
 */

 // expresion
 /*
 indicador: expresion (('+'|'-') indicador) | expresion ;
 
 expresion : termino (('*'|'/') expresion) | termino ;

 termino : factor ('^' termino) | factor ;

 factor : '(' TERMINOFINAL ')' | TERMINOFINAL
 */

indicador : producto (('+'|'-') indicador) | producto;
producto : factor (('*'|'/') producto) | factor;
factor : exponente ('^' factor) | exponente;
exponente : '(' indicador ')' | TERMINO ; 

 // reglas


 TERMINO: NUMERO | CONSTANTE | CUENTA ;

 NUMERO: ('1'..'9')('0'..'9')* ;

 CONSTANTE: ('a'..'z')+ | ('A'..'Z')+ ;

 CUENTA: 'EBITDA' | 'FDS' | 'FCF' | 'INOD' | 'INOC' ;


compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

WS : (' '|'\t'|'\n'|'\r') -> channel(HIDDEN);