grammar gramatica;

/*
 * Parser Rules
 */

 num		: SEPARADORDECIMAL INT 
			| INT ( SEPARADORDECIMAL INT )?
			;

expr	: expr MAS expr									# suma
		| expr MENOS expr								# resta
		| expr POR expr									# producto
		| expr DIVIDIDO expr							# division
		| PARENTESISIZQUIERDO expr PARENTESISDERECHO    # parentesis
		| INDICADOR										# indicador
		| num											# numero
		;

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

INT							: [0-9]+	;
MAS							: '+'		;
MENOS						: '-'		;
POR							: '*'		;
DIVIDIDO					: '/'		;
PARENTESISIZQUIERDO			: '('		;
PARENTESISDERECHO			: ')'		;
INDICADOR					: [a-zA-Z]+ ;
SEPARADORDECIMAL			: '.'|','	;
WS							: (' '|'\t'|'\n'|'\r') -> channel(HIDDEN) ;
