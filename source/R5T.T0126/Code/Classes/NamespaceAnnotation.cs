using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class NamespaceAnnotation : SyntaxNodeAnnotation<NamespaceDeclarationSyntax>
    {
        #region Static

        public static NamespaceDeclarationSyntax From(NamespaceDeclarationSyntax namespaceDeclaration,
            out NamespaceAnnotation namespaceAnnotation)
        {
            var output = namespaceDeclaration.Annotate(out var annotation);

            namespaceAnnotation = NamespaceAnnotation.From(annotation);

            return output;
        }

        public static NamespaceAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new NamespaceAnnotation(annotation);
            return output;
        }

        #endregion


        public NamespaceAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
