using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxNodeSyntaxAnnotation
    {
        #region Static

        public static SyntaxNodeSyntaxAnnotation<TNode> From<TNode>(SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeSyntaxAnnotation<TNode>(annotation);
            return output;
        }

        public static SyntaxNodeSyntaxAnnotation<TNode> From<TNode>(TNode _,
            SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeSyntaxAnnotation<TNode>(annotation);
            return output;
        }

        #endregion
    }



    public class SyntaxNodeSyntaxAnnotation<TNode> : TypedSyntaxAnnotation<TNode>
        where TNode : SyntaxNode
    {
        public SyntaxNodeSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
