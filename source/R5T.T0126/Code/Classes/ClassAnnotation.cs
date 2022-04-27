using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class ClassAnnotation : SyntaxNodeAnnotation<ClassDeclarationSyntax>
    {
        #region Static

        public static ClassDeclarationSyntax From(ClassDeclarationSyntax classDeclaration,
            out ClassAnnotation classAnnotation)
        {
            var output = classDeclaration.Annotate(out var annotation);

            classAnnotation = ClassAnnotation.From(annotation);

            return output;
        }

        public static ClassAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new ClassAnnotation(annotation);
            return output;
        }

        #endregion


        public ClassAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
