using System;
using System.Text;
using System.Collections.Generic;
using Google.OrTools.ConstraintSolver;

/// <summary>
///   Minimal TSP using distance matrix.
/// </summary>
namespace TravellingSalesmanProblem {
    public class TspCities {
        /// <summary>
        ///   Print the solution.
        /// </summary>
        static string PrintSolution(RoutingModel routing, RoutingIndexManager manager, Assignment solution) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Objective: {0} miles\r\n", solution.ObjectiveValue());
            // Inspect solution.
            sb.AppendFormat("Route:");
            long routeDistance = 0;
            var index = routing.Start(0);
            while (routing.IsEnd(index) == false) {
                sb.AppendFormat("{0} -> ", manager.IndexToNode((int)index));
                var previousIndex = index;
                index = solution.Value(routing.NextVar(index));
                routeDistance += routing.GetArcCostForVehicle(previousIndex, index, 0);
            }
            sb.AppendFormat("{0}\r\n", manager.IndexToNode((int)index));
            sb.AppendFormat("Route distance: {0}miles\r\n", routeDistance);
            return sb.ToString();
        }

        static int[] GetOrder(RoutingModel routing, RoutingIndexManager manager, Assignment solution) {
            List<int> order = new List<int>();
            var index = routing.Start(0);
            while (routing.IsEnd(index) == false) {
                order.Add(manager.IndexToNode((int)index));
                index = solution.Value(routing.NextVar(index));
            }
            return order.ToArray();
        }

        public static int[] Run(long[] DistanceMatrix, int num, int VehicleNumber, int Depot, RoutingSearchParameters searchParameters) {
            // Instantiate the data problem.
            // Create Routing Index Manager
            RoutingIndexManager manager = new RoutingIndexManager(
                num,
                VehicleNumber,
                Depot);

            // Create Routing Model.
            RoutingModel routing = new RoutingModel(manager);

            int transitCallbackIndex = routing.RegisterTransitCallback(
                (long fromIndex, long toIndex) => {
                    // Convert from routing variable Index to distance matrix NodeIndex.
                    var fromNode = manager.IndexToNode(fromIndex);
                    var toNode = manager.IndexToNode(toIndex);
                    return DistanceMatrix[fromNode * num +  toNode];
                }
            );

            // Define cost of each arc.
            routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);

            // Solve the problem.
            Assignment solution = routing.SolveWithParameters(searchParameters);

            // Print solution on console.
            return GetOrder(routing, manager, solution);
        }
    }
}