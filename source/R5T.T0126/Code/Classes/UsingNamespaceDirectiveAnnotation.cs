using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class UsingNamespaceDirectiveAnnotation : UsingDirectiveAnnotation
    {
        #region Static

        public static new UsingNamespaceDirectiveAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new UsingNamespaceDirectiveAnnotation(annotation);
            return output;
        }

        public static UsingNamespaceDirectiveAnnotation From(UsingDirectiveAnnotation annotation)
        {
            var output = new UsingNamespaceDirectiveAnnotation(annotation.SyntaxAnnotation);
            return output;
        }

        #endregion


        public UsingNamespaceDirectiveAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
