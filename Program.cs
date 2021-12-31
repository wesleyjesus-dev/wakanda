using k8s;

var config = KubernetesClientConfiguration.BuildDefaultConfig();
IKubernetes client = new Kubernetes(config);

var currentNamespace = config.Namespace;

var deployments = client.ListNamespacedDeployment(currentNamespace);

Console.Write("######## Deployment ########\n");
foreach (var deployment in deployments.Items)
{
    Console.Write($"Name: {deployment.Metadata.Name}\n");
    Console.Write($"Available Replicas: {deployment.Status.AvailableReplicas}\n");
}