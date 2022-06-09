using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxNodeAnnotation : TypedSyntaxAnnotation, ISyntaxNodeAnnotation
    {
        #region Static

        /// <summary>
        /// For initializing syntax node annotations (perhaps when the value is set within anonymous functions).
        /// </summary>
        public static ISyntaxNodeAnnotation<TNode> Initialize<TNode>()
            where TNode : SyntaxNode
        {
            return null;
        }

        public static SyntaxNodeAnnotation<TNode> From<TNode>(SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeAnnotation<TNode>(annotation);
            return output;
        }

        public static SyntaxNodeAnnotation<TNode> From<TNode>(TNode _,
            SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeAnnotation<TNode>(annotation);
            return output;
        }

        #endregion


        public SyntaxNodeAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }


    public class SyntaxNodeAnnotation<TNode> : TypedSyntaxAnnotation<TNode>, ISyntaxNodeAnnotation<TNode>
        where TNode : SyntaxNode
    {
        public SyntaxNodeAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
