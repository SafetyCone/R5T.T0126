using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0126;


namespace System
{
    public static class NamespaceDeclarationSyntaxExtensions
    {
        public static NamespaceDeclarationSyntax AnnotateTyped(this NamespaceDeclarationSyntax namespaceDeclaration,
            out NamespaceAnnotation annotation)
        {
            var output = NamespaceAnnotation.From(namespaceDeclaration, out annotation);
            return output;
        }
    }
}
