using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class TypeSyntaxAnnotation : SyntaxNodeAnnotation<TypeSyntax>
    {
        #region Static

        public static TypeSyntaxAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new TypeSyntaxAnnotation(annotation);
            return output;
        }

        #endregion


        public TypeSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
