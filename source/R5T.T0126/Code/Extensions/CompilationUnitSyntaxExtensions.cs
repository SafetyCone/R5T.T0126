using System;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0126;


namespace System
{
    public static partial class CompilationUnitSyntaxExtensions
    {
        public static CompilationUnitSyntax GetUsingsAnnotated(this CompilationUnitSyntax compilationUnit,
            out UsingDirectiveAnnotation[] usingDirectiveAnnotations)
        {
            var usingDirectives = compilationUnit.GetUsings();

            var outputCompilationUnit = compilationUnit.AnnotateNodes_Typed(
                usingDirectives,
                UsingDirectiveAnnotation.From,
                out var annotationsByInputNode);

            usingDirectiveAnnotations = annotationsByInputNode.Values.ToArray();

            return outputCompilationUnit;
        }
    }
}