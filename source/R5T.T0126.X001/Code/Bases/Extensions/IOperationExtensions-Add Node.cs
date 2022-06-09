using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0126;

using IOperation = R5T.T0098.IOperation;


namespace System
{
    public static partial class IOperationExtensions
    {
        /// <summary>
        /// Method establishing a framework for adding a node to a parent node.
        /// Framework returns an annotation to the node, and a new parent node instance modified to include the node to be added.
        /// </summary>
        /// <typeparam name="TParentNode">The node to which a node should be added.</typeparam>
        /// <typeparam name="TNode">The node to add.</typeparam>
        public static (TParentNode, ISyntaxNodeAnnotation<TNode>) AddNode<TParentNode, TNode>(this IOperation _,
            TParentNode parentNode,
            TNode node,
            Func<TNode, TNode> preAdd,
            Func<TParentNode, TNode, TParentNode> add,
            Func<TParentNode, ISyntaxNodeAnnotation<TNode>, TParentNode> postAdd)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            return parentNode.AddNode(
                node,
                preAdd,
                add,
                postAdd);
        }

        /// <inheritdoc cref="AddNode{TParentNode, TNode}(IOperation, TParentNode, TNode, Func{TNode, TNode}, Func{TParentNode, TNode, TParentNode}, Func{TParentNode, ISyntaxNodeAnnotation{TNode}, TParentNode})"/>
        public static Task<(TParentNode, ISyntaxNodeAnnotation<TNode>)> AddNode<TParentNode, TNode>(this IOperation _,
            TParentNode parentNode,
            TNode node,
            Func<TNode, Task<TNode>> preAdd,
            Func<TParentNode, TNode, Task<TParentNode>> add,
            Func<TParentNode, ISyntaxNodeAnnotation<TNode>, Task<TParentNode>> postAdd)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            return parentNode.AddNode(
                node,
                preAdd,
                add,
                postAdd);
        }
    }
}
