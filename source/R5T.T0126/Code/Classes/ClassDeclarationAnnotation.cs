using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class ClassDeclarationAnnotation : SyntaxNodeSyntaxAnnotation<ClassDeclarationSyntax>
    {
        #region Static

        public static ClassDeclarationAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new ClassDeclarationAnnotation(annotation);
            return output;
        }

        #endregion


        public ClassDeclarationAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
