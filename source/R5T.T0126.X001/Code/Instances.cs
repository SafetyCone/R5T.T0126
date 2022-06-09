using System;

using R5T.L0011.T001;
using R5T.T0098;


namespace R5T.T0126.X001
{
    public static class Instances
    {
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static ISyntaxFactory SyntaxFactory { get; } = L0011.T001.SyntaxFactory.Instance;
    }
}
