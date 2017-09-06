grammar GMetodologias;

metodologia: INDICADOR OPERADOR INDICADOR;

OPERADOR: '>'|'<'|'=';
INDICADOR: ('a'..'z')+ | ('A'..'Z')+ ;

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

WS
	:	' ' -> channel(HIDDEN)
	;
