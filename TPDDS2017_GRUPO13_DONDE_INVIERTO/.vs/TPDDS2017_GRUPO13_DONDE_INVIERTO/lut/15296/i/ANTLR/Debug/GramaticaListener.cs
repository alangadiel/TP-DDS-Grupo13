//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\adria\OneDrive\Documentos\TP-DDS-Grupo13\TPDDS2017_GRUPO13_DONDE_INVIERTO\ANTLR\ANTLR\Gramatica.g4 by ANTLR 4.6.4

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ANTLR {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GramaticaParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.4")]
[System.CLSCompliant(false)]
public interface IGramaticaListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaParser.indicador"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndicador([NotNull] GramaticaParser.IndicadorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaParser.indicador"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndicador([NotNull] GramaticaParser.IndicadorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaParser.producto"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProducto([NotNull] GramaticaParser.ProductoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaParser.producto"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProducto([NotNull] GramaticaParser.ProductoContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFactor([NotNull] GramaticaParser.FactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFactor([NotNull] GramaticaParser.FactorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaParser.exponente"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExponente([NotNull] GramaticaParser.ExponenteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaParser.exponente"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExponente([NotNull] GramaticaParser.ExponenteContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="GramaticaParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompileUnit([NotNull] GramaticaParser.CompileUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GramaticaParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompileUnit([NotNull] GramaticaParser.CompileUnitContext context);
}
} // namespace ANTLR
