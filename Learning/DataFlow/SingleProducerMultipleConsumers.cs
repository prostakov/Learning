using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Common;
using NUnit.Framework;

namespace DataFlow
{
    public class SingleProducerMultipleConsumers : BaseTest
    {
        [Test]
        public async Task Test()
        {
            var producer = CreateProducer(); 
            
            var consumer1 = CreateConsumer("Consumer1");
            var consumer2 = CreateConsumer("Consumer2");

            producer.LinkTo(consumer1, new DataflowLinkOptions {PropagateCompletion = true});
            producer.LinkTo(consumer2, new DataflowLinkOptions {PropagateCompletion = true});

            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();
            sw1.Start();
            sw2.Start();

            for (int i = 0; i < 20; i++)
            {
                if (producer.Post(i))
                    Logger.Information("Successful post");
                else
                    Logger.Information("Failed post");
            }
            
            producer.Complete();
            
            var completion1 = consumer1.Completion.ContinueWith(p =>
            {
                sw1.Stop();
                Logger.Information($"Done1 - {sw1.ElapsedMilliseconds}ms");
            });
            
            
            var completion2 = consumer2.Completion.ContinueWith(p =>
            {
                sw2.Stop();
                Logger.Information($"Done2 - {sw2.ElapsedMilliseconds}ms");
            });

            await Task.WhenAll(completion1, completion2);
        }
    
        private ActionBlock<int> CreateConsumer(string name)
        {
            return new(async timeout =>
            {
                await Task.Delay(timeout);
                Logger.Information($"{DateTime.Now.Millisecond} Action block '{name}' - {timeout}");
            }, new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 1, BoundedCapacity = 2});
        }

        private TransformBlock<int, int> CreateProducer()
        {
            var block = new TransformBlock<int, int>(input => input * 2);
            return block;
        }
    }
}