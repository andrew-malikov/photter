using System.Collections.Generic;
using System.CommandLine;

namespace Photter.Interface.Handlers.Old {
    public class RootHandler {
        public readonly RootCommand Root;

        public RootHandler(
            RootCommand root,
            IEnumerable<INestedHandler> nestedHandlers
        ) {
            foreach (var handler in nestedHandlers) {
                root.AddCommand(handler.Command);
            }

            Root = root;
        }
    }
}