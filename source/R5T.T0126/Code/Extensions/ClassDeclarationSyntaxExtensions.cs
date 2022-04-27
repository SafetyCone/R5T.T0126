using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0126;


namespace System
{
    public static class ClassDeclarationSyntaxExtensions
    {
        public static ClassDeclarationSyntax AnnotateTyped(this ClassDeclarationSyntax classDeclaration,
            out ClassAnnotation annotation)
        {
            var output = ClassAnnotation.From(classDeclaration, out annotation);
            return output;
        }
    }
}
